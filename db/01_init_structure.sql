CREATE TABLE IF NOT EXISTS public.message
(
    id                   serial           primary key,
    nom                  varchar          not null,
    description          varchar          not null,
    date_cree            timestamp with time zone
);