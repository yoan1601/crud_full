CREATE  TABLE departement ( 
	iddept               serial  NOT NULL  ,
	nomdept              varchar(255)  NOT NULL  ,
	CONSTRAINT pk_departement PRIMARY KEY ( iddept )
 );

CREATE  TABLE employe ( 
	idemploye            serial  NOT NULL  ,
	nom                  varchar(255)  NOT NULL  ,
	datenaissance        timestamp  NOT NULL  ,
	iddept               integer  NOT NULL  ,
	CONSTRAINT pk_employe PRIMARY KEY ( idemploye )
 );

ALTER TABLE employe ADD CONSTRAINT fk_employe_departement FOREIGN KEY ( iddept ) REFERENCES departement( iddept );