CREATE  TABLE departement ( 
	iddept               serial  NOT NULL  ,
	nomdept              varchar(255)  NOT NULL  ,
	CONSTRAINT pk_departement PRIMARY KEY ( iddept )
 );

CREATE  TABLE employe ( 
	idemploye            serial  NOT NULL  ,
	nom                  varchar(255)  NOT NULL  ,
	datenaissance        timestamp without time zone  NOT NULL  ,
	iddept               integer  NOT NULL  ,
	CONSTRAINT pk_employe PRIMARY KEY ( idemploye )
 );


ALTER TABLE employe ADD CONSTRAINT fk_employe_departement FOREIGN KEY ( iddept ) REFERENCES departement( iddept );

 INSERT INTO departement (nomdept) VALUES
  ('Ressources Humaines'),
  ('Développement'),
  ('Marketing'),
  ('Finance'),
  ('Support Technique');

INSERT INTO employe (nom, datenaissance, iddept) VALUES
  ('John Doe', '1990-05-15', 1),
  ('Alice Smith', '1985-08-22', 2),
  ('Bob Johnson', '1988-11-10', 3),
  ('Eva Martinez', '1992-04-03', 2),
  ('Michael Brown', '1980-09-28', 4);