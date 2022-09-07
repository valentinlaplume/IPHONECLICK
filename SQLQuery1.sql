 CREATE DATABASE dbIphoneClick

GO 
USE dbIphoneClick
GO

DROP TABLE CATEGORIA
CREATE TABLE CATEGORIA(
Id int PRIMARY KEY IDENTITY,
Descripcion nvarchar(100),
FechaRegistro DATETIME DEFAULT GETDATE(),
Estado bit default 1
)

GO

--DROP TABLE MARCA
CREATE TABLE MARCA
(
Id int PRIMARY KEY IDENTITY,
Descripcion nvarchar(100),
FechaRegistro DATETIME DEFAULT GETDATE(),
Estado bit default 1
)

GO
--SELECT * FROM producto
--DROP TABLE producto
CREATE TABLE PRODUCTO(
Id int PRIMARY KEY IDENTITY,
Nombre nvarchar(50),
Descripcion nvarchar(100),
IdCategoria int REFERENCES CATEGORIA(Id),
IdMarca int REFERENCES MARCA(Id),
Precio decimal(10,2) default 0,
Stock int default 1,
RutaImagen nvarchar(100),
NombreImagen nvarchar(100),
FechaRegistro DATETIME DEFAULT GETDATE(),
Estado bit default 1
)

GO



--DROP TABLE USUARIO
CREATE TABLE USUARIO(
Id int PRIMARY KEY IDENTITY,
Nombre nvarchar(50) NOT NULL,
Apellido nvarchar(50) NOT NULL,
Correo nvarchar(100) NOT NULL,
Constraseña nvarchar(100),
Restablecer bit default 0,
FechaRegistro DATETIME DEFAULT GETDATE(),
Estado bit default 1
)

-------------------------------------------------------------
--select top 1 * from USUARIO order by FechaRegistro asc

--UPDATE USUARIO SET Constraseña = 'aaa' where id = 6

--SELECT Id,Nombre,Apellido,Correo,Constraseña,Restablecer,Estado FROM USUARIO

--insert into  usuario(Nombre,Apellido, Correo)
--values
--('sofia',
--'revuelta',
--'srevueltadelariva@gmail.com'
--)

--DELETE FROM USUARIO WHERE Id <> 1

--delete usuario where id = 6

 -- 6


ALTER PROC sp_RegistrarUsuario(
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Correo nvarchar(100),
@Constraseña nvarchar(100),
@Estado bit,
@Mensaje nvarchar(500) output,
@Resultado int output
)
AS 
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM USUARIO WHERE Correo = @Correo)
	BEGIN
		INSERT INTO USUARIO(Nombre,Apellido,Correo,Constraseña,Estado) 
		VALUES (@Nombre,@Apellido,@Correo,@Constraseña,@Estado)
		SET @Resultado = SCOPE_IDENTITY()
		SET @Mensaje = 'El Usuario fue registrado con éxito.'
	END
    ELSE
		SET @Mensaje = 'El correo del Usuario ya existe.'
END
 
go

ALTER PROC sp_EditarUsuario(
@Id int,
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@Correo nvarchar(100),
@Estado bit,
@Mensaje nvarchar(500) output,
@Resultado bit output
)
AS 
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM USUARIO WHERE Id != @Id
	and Correo = @Correo)
	BEGIN

		UPDATE TOP (1) USUARIO SET
		Nombre = @Nombre,
		Apellido = @Apellido,
		Correo = @Correo,
		Estado = @Estado
		WHERE Id = @Id

		SET @Resultado = 1
		SET @Mensaje = 'El Usuario fue editado con éxito.'
	END
    ELSE
		SET @Mensaje = 'El correo del Usuario ya existe.'
END

select * from CATEGORIA

insert into  CATEGORIA(Descripcion)
valueS ('FUNDAS'),('ACCESORIOS')
-----------------------------------------------------------
ALTER PROC sp_RegistrarCategoria(
@Descripcion nvarchar(100),
@Estado bit,
@Mensaje nvarchar(500) output,
@Resultado int output
)
AS 
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
    begin
        insert into CATEGORIA (Descripcion, Estado) VALUES
		(@Descripcion, @Estado)
        SET @Resultado = scope_identity()
		SET @Mensaje = 'La Categoria fue registrada correctamente.'
    END
    ELSE
     SET @Mensaje = 'La Categoria ya existe.'
END

go


ALTER PROC sp_EditarCategoria(
@Id int,
@Descripcion nvarchar(100),
@Estado bit,
@Mensaje nvarchar(500) output,
@Resultado int output
)
AS 
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM CATEGORIA
	WHERE Descripcion = @Descripcion AND Id != @Id)
	BEGIN
		UPDATE TOP (1) CATEGORIA SET
		Descripcion = @Descripcion,
		Estado = @Estado
		WHERE Id = @Id

		SET @Resultado = 1
		SET @Mensaje = 'La Categoria fue editada con éxito.'
	END
    ELSE
		SET @Mensaje = 'La Categoria ya existe.'
END

go


ALTER PROC sp_EliminarCategoria(
@Id int,
@Mensaje nvarchar(500) output,
@Resultado int output
)
AS 
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM PRODUCTO p
	INNER JOIN CATEGORIA c on c.Id = p.IdCategoria
	WHERE p.IdCategoria = @Id)
		BEGIN
			DELETE TOP (1) FROM CATEGORIA WHERE Id = @Id
			SET @Resultado = 1
		END
	ELSE
		SET @Mensaje = 'La Categoria se encuentra relacionada a un producto.'
END

------------------------------------------------------------------------
ALTER PROC sp_RegistrarMarca(
@Descripcion nvarchar(100),
@Estado bit,
@Mensaje nvarchar(500) output,
@Resultado int output
)
AS 
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM MARCA WHERE Descripcion = @Descripcion)
    begin
        insert into MARCA (Descripcion, Estado) VALUES
		(@Descripcion, @Estado)
        SET @Resultado = scope_identity()
		SET @Mensaje = 'La Marca fue registrada correctamente.'
    END
    ELSE
     SET @Mensaje = 'La Marca ya existe.'
END

go


ALTER PROC sp_EditarMarca(
@Id int,
@Descripcion nvarchar(100),
@Estado bit,
@Mensaje nvarchar(500) output,
@Resultado int output
)
AS 
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM MARCA
	WHERE Descripcion = @Descripcion AND Id != @Id)
	BEGIN
		UPDATE TOP (1) MARCA SET
		Descripcion = @Descripcion,
		Estado = @Estado
		WHERE Id = @Id

		SET @Resultado = 1
		SET @Mensaje = 'La Marca fue editada con éxito.'
	END
    ELSE
		SET @Mensaje = 'La Marca ya existe.'
END

go


ALTER PROC sp_EliminarMarca(
@Id int,
@Mensaje nvarchar(500) output,
@Resultado int output
)
AS 
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM PRODUCTO p
	INNER JOIN MARCA c on c.Id = p.IdCategoria
	WHERE p.IdCategoria = @Id)
		BEGIN
			DELETE TOP (1) FROM CATEGORIA WHERE Id = @Id
			SET @Resultado = 1
		END
	ELSE
		SET @Mensaje = 'La Marca se encuentra relacionada a un producto.'
END

SELECT * FROM MARCA
insert into  MARCA(Descripcion)
valueS ('APPLE'),('GENÉRICA')

--------------------------------------------------
ALTER proc sp_RegistrarProducto(
@Nombre varchar (100),
@Descripcion varchar (100),
@IdMarca int,
@IdCategoria int,
@Precio decimal(10,2),
@Stock int,
@Mensaje nvarchar(500) output,
@Resultado int output
)
as
begin
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Nombre = @Nombre)
	begin
        insert into PRODUCTO (Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock) values
        (@Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio, @stock)
        SET @Resultado = scope_identity()
		SET @Mensaje = 'El producto fue registrado correctamente.'
    end
    else
     set @Mensaje = 'El producto ya existe.'
end



ALTER proc sp_EditarProducto(
@IdProducto int,
@Nombre varchar (100),
@Descripcion varchar (100),
@IdMarca int,
@IdCategoria int,
@Precio decimal(10,2),
@Stock int,
@Activo bit,
@Mensaje varchar (500) output,
@Resultado bit output
)
as
begin
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Nombre = @Nombre and Id != @IdProducto)
    begin
        update PRODUCTO set
			Nombre = @Nombre,
			Descripcion = @Descripcion,
			IdMarca = @IdMarca,
			Idcategoria = @IdCategoria,
			Precio = @Precio,
			Stock = @stock,
			Estado = @Activo
        where Id = @IdProducto
                
        SET @Resultado = 1
		SET @Mensaje = 'El producto fue editado con éxito.'

    end
    else
     set @Mensaje = 'El producto ya existe.'
end


create proc sp_EliminarProducto(
@IdProducto int,
@Mensaje varchar (580) output,
@Resultado bit output
as
begin
    SET @Resultado = 0
   IF NOT EXISTS (select • from DETALLE_VENTA dv
    inner join PRODUCTO p on p.IdProducto dv. IdProducto
    where p.IdProducto @IdProducto)
    begin
        delete top (1) from PRODUCTO where IdProducto = @IdProducto
        SET @Resultado = 1
    end
    else
     set @Mensaje = 'El producto se encuentra relacionado a una venta'
end



