-- Drop table

-- DROP TABLE public.cities;

CREATE TABLE public.cities (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT cities_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.cities OWNER TO postgres;
GRANT ALL ON TABLE public.cities TO postgres;


-- public.countries определение

-- Drop table

-- DROP TABLE public.countries;

CREATE TABLE public.countries (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	russian_name varchar NOT NULL,
	english_name varchar NOT NULL,
	first_code varchar NOT NULL,
	second_code int4 NOT NULL,
	CONSTRAINT countries_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.countries OWNER TO postgres;
GRANT ALL ON TABLE public.countries TO postgres;


-- public.direction определение

-- Drop table

-- DROP TABLE public.direction;

CREATE TABLE public.direction (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT direction_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.direction OWNER TO postgres;
GRANT ALL ON TABLE public.direction TO postgres;


-- public.genders определение

-- Drop table

-- DROP TABLE public.genders;

CREATE TABLE public.genders (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT genders_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.genders OWNER TO postgres;
GRANT ALL ON TABLE public.genders TO postgres;


-- public.images_city определение

-- Drop table

-- DROP TABLE public.images_city;

CREATE TABLE public.images_city (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	image_path varchar NOT NULL,
	CONSTRAINT images_city_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.images_city OWNER TO postgres;
GRANT ALL ON TABLE public.images_city TO postgres;


-- public.moderators_events определение

-- Drop table

-- DROP TABLE public.moderators_events;

CREATE TABLE public.moderators_events (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT moderators_events_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.moderators_events OWNER TO postgres;
GRANT ALL ON TABLE public.moderators_events TO postgres;


-- public.user_states определение

-- Drop table

-- DROP TABLE public.user_states;

CREATE TABLE public.user_states (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT user_states_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.user_states OWNER TO postgres;
GRANT ALL ON TABLE public.user_states TO postgres;


-- public.images_cities определение

-- Drop table

-- DROP TABLE public.images_cities;

CREATE TABLE public.images_cities (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	name_id uuid NOT NULL,
	image_id uuid NULL,
	CONSTRAINT images_cities_pk PRIMARY KEY (id),
	CONSTRAINT images_cities_cities_fk FOREIGN KEY (name_id) REFERENCES public.cities(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT images_cities_images_city_fk FOREIGN KEY (image_id) REFERENCES public.images_city(id) ON DELETE RESTRICT ON UPDATE CASCADE
);

-- Permissions

ALTER TABLE public.images_cities OWNER TO postgres;
GRANT ALL ON TABLE public.images_cities TO postgres;


-- public.users определение

-- Drop table

-- DROP TABLE public.users;

CREATE TABLE public.users (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	full_name varchar NOT NULL,
	gender_id uuid NOT NULL,
	state_id uuid NOT NULL,
	email varchar NOT NULL,
	birthday date NOT NULL,
	country_id uuid NOT NULL,
	phone varchar NOT NULL,
	"password" varchar NOT NULL,
	image_path varchar NULL,
	CONSTRAINT users_pk PRIMARY KEY (id),
	CONSTRAINT users_countries_fk FOREIGN KEY (country_id) REFERENCES public.countries(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT users_genders_fk FOREIGN KEY (gender_id) REFERENCES public.genders(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT users_states_fk FOREIGN KEY (state_id) REFERENCES public.user_states(id) ON DELETE RESTRICT ON UPDATE CASCADE
);

-- Permissions

ALTER TABLE public.users OWNER TO postgres;
GRANT ALL ON TABLE public.users TO postgres;


-- public.events определение

-- Drop table

-- DROP TABLE public.events;

CREATE TABLE public.events (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	"name" varchar NOT NULL,
	image_path varchar NOT NULL,
	date_event date NOT NULL,
	days int4 NOT NULL,
	city_id uuid NOT NULL,
	winner_id uuid NULL,
	CONSTRAINT events_pk PRIMARY KEY (id),
	CONSTRAINT events_cities_fk FOREIGN KEY (city_id) REFERENCES public.cities(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT events_users_fk FOREIGN KEY (winner_id) REFERENCES public.users(id) ON DELETE RESTRICT ON UPDATE CASCADE
);

-- Permissions

ALTER TABLE public.events OWNER TO postgres;
GRANT ALL ON TABLE public.events TO postgres;


-- public.jury определение

-- Drop table

-- DROP TABLE public.jury;

CREATE TABLE public.jury (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	direction_id uuid NOT NULL,
	user_id uuid NOT NULL,
	CONSTRAINT jury_pk PRIMARY KEY (id),
	CONSTRAINT unique_user_id_jury UNIQUE (user_id),
	CONSTRAINT jury_direction_fk FOREIGN KEY (direction_id) REFERENCES public.direction(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT jury_users_fk FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE RESTRICT ON UPDATE CASCADE
);

-- Permissions

ALTER TABLE public.jury OWNER TO postgres;
GRANT ALL ON TABLE public.jury TO postgres;


-- public.moderators определение

-- Drop table

-- DROP TABLE public.moderators;

CREATE TABLE public.moderators (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	direction_id uuid NOT NULL,
	moderator_event_id uuid NOT NULL,
	user_id uuid NOT NULL,
	CONSTRAINT moderators_pk PRIMARY KEY (id),
	CONSTRAINT unique_user_id_moderators UNIQUE (user_id),
	CONSTRAINT moderators_direction_fk FOREIGN KEY (direction_id) REFERENCES public.direction(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT moderators_moderators_events_fk FOREIGN KEY (moderator_event_id) REFERENCES public.moderators_events(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT moderators_users_fk FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE RESTRICT ON UPDATE CASCADE
);
CREATE INDEX moderators_user_id_idx ON public.moderators USING btree (user_id);

-- Permissions

ALTER TABLE public.moderators OWNER TO postgres;
GRANT ALL ON TABLE public.moderators TO postgres;


-- public.activities определение

-- Drop table

-- DROP TABLE public.activities;

CREATE TABLE public.activities (
	id uuid DEFAULT gen_random_uuid() NOT NULL,
	"name" varchar NOT NULL,
	number_day int4 NOT NULL,
	time_start time NOT NULL,
	moderator_id uuid NULL,
	first_jury_id uuid NULL,
	second_jury_id uuid NULL,
	third_jury_id uuid NULL,
	fourth_jury_id uuid NULL,
	fifth_jury_id uuid NULL,
	event_id uuid NOT NULL,
	CONSTRAINT activities_pk PRIMARY KEY (id),
	CONSTRAINT activities_events_fk FOREIGN KEY (event_id) REFERENCES public.events(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT activities_jury_fk FOREIGN KEY (first_jury_id) REFERENCES public.jury(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT activities_jury_fk_1 FOREIGN KEY (second_jury_id) REFERENCES public.jury(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT activities_jury_fk_2 FOREIGN KEY (third_jury_id) REFERENCES public.jury(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT activities_jury_fk_3 FOREIGN KEY (fourth_jury_id) REFERENCES public.jury(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT activities_jury_fk_4 FOREIGN KEY (fifth_jury_id) REFERENCES public.jury(id) ON DELETE RESTRICT ON UPDATE CASCADE,
	CONSTRAINT activities_moderators_fk FOREIGN KEY (moderator_id) REFERENCES public.moderators(id) ON DELETE RESTRICT ON UPDATE CASCADE
);

-- Permissions

ALTER TABLE public.activities OWNER TO postgres;
GRANT ALL ON TABLE public.activities TO postgres;




-- Permissions

GRANT ALL ON SCHEMA public TO pg_database_owner;
GRANT USAGE ON SCHEMA public TO public;