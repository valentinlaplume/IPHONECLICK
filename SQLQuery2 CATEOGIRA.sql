CREATE PROC sp_RegistrarCategoria(
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
		SET @Mensaje = 'La Categoria fue registrada correctamente'
    END
    ELSE
     SET @Mensaje = 'La Categoria ya existe.'
END

go


CREATE PROC sp_EditarCategoria(
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
