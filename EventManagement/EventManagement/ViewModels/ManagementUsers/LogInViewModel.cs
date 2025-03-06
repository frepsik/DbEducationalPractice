using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using EventManagement.Models;
using EventManagement.Models.Captcha;
using EventManagement.Models.Database;
using EventManagement.Models.Database.Queries;
using ReactiveUI;

namespace EventManagement.ViewModels.ManagementUsers
{
	public class LogInViewModel : ViewModelBase
	{
        string password, login, enterCaptchaText, error;
        Bitmap captchaImage;
        int quantityError;
        bool isEnabledButtonEntry;


        public LogInViewModel()
        {
            GenerateNewCaptcha();
            //В связи с тем, что данных не много, не имеет смысла прописывать запрос на доставание конкретного пользователя по логину
            Users = Get.AllUsers();
            quantityError = 0;
            IsEnabledButtonEntry = true;
        }
        

        public string Password 
        {
            get => password;
            set
            {
                Error = string.Empty;
                this.RaiseAndSetIfChanged(ref password, value);
            }
               
        }
        public string Login 
        {
            get => login;
            set
            {
                Error = string.Empty;
                this.RaiseAndSetIfChanged(ref login, value);
            } 
            
        }
        public string EnterCaptchaText 
        { 
            get => enterCaptchaText;
            set
            {
                Error = string.Empty;
                this.RaiseAndSetIfChanged(ref enterCaptchaText, value);
            }
        }
        string CaptchaText { get; set; }
        internal CaptchaGenereate CaptchaGenerate { get; private set; }
        public Bitmap CaptchaImage { get => captchaImage; set => this.RaiseAndSetIfChanged(ref captchaImage, value); }
        List<User>? Users { get; set; }
        public string Error { get => error; set => this.RaiseAndSetIfChanged(ref error, value); }
        public bool IsEnabledButtonEntry { get => isEnabledButtonEntry; set => this.RaiseAndSetIfChanged(ref isEnabledButtonEntry, value); }


        /// <summary>
        /// Проверка введённых данных
        /// </summary>
        /// <returns></returns>
        public async Task CheckPersonalData()
        {
            Error = string.Empty;
            if (Users is null)
            {
                Error = "Произошла ошибка в ходе обработки данных. Повторите попытку позже";
                return;
            }
            else
            {
                
                User? userAuth = Users.FirstOrDefault(p => p.Id.ToString() == Login && p.Password == Password);
                if (userAuth is not null)
                {
                    if (EnterCaptchaText == CaptchaText)
                    {
                        //Добавляем пользователя на время работы системы
                        AuthorizedUser.UserInstance.EditPersonalDataUser(userAuth);

                        MainWindowViewModel.Navigation.NavigateToUserView();
                    }
                    else
                    {
                        EnterCaptchaText = string.Empty;
                        Error = "Неверно ведено значение CAPTCHA. Повторите попытку";                       
                        GenerateNewCaptcha();
                        return;
                    }
                }
                else
                {
                    //Сработали 3 ошибки в вводе персональных данных, ожидаем 10 секунд
                    if (quantityError == 3)
                    {
                        IsEnabledButtonEntry = false;
                        quantityError = 0;                       
                        for (int i = 10; i >= 1; i--)
                        {
                            Error = $"Повторите попытку через {i} секунд";
                            await Task.Delay(1000);
                        }
                        EnterCaptchaText = string.Empty;
                        IsEnabledButtonEntry = true;
                    }
                    else
                    {
                        quantityError++;
                        Error = "Неверно введён логин или пароль. Повторите попытку";
                        return;
                    }                  
                }    
            }
        }
        
        public void GenerateNewCaptcha()
        {
            CaptchaGenerate = new CaptchaGenereate();
            CaptchaText = CaptchaGenerate.GenerateCaptchaText();
            CaptchaImage = CaptchaGenerate.GenerateCaptchaImage(CaptchaText);
        }
    }
}