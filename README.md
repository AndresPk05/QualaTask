# QualaTask

Script de SQL para ejecutar:

# Crear base de datos

CREATE DATABASE "Quola"

# Insert tabla monedas

INSERT INTO Monedas values ('COP', 'Pesos')

INSERT INTO Monedas values ('USD', 'Dolares')

INSERT INTO Monedas values ('PE', 'Soles')

# Migracion EF

Una vez se cree la base de datos se puede realizar la migracion con los siguientes comandos:

Add-migration Initial
Update-database

# Nota

en el appsetting del proyecto back en .Net se debe cambiar la cadena de conexion para apuntar al motor de base de datos SQL Server que se esten manejando
