CREATE TABLE video(
idVideo int primary key,
titulo varchar (100),
repro int,
url varchar(100)
);

CREATE PROCEDURE sp_video_insertar
@idVideo int,
@titulo varchar(100),
@repro int,
@url varchar(100)
as
begin
	INSERT INTO video
	VALUES(@idVideo,@titulo,@repro,@url)
end

EXEC sp_video_insertar 2,'Video',1,'https://www.youtube.com/embed/85Xm5UTmbGM'
EXEC sp_video_insertar 1, 'CR7', 280, 'https://www.youtube.com/embed/v=vtglBn3jCpo'

drop procedure SP_video_ACTUALIZAR

CREATE PROCEDURE SP_video_ACTUALIZAR
@idVideo int,
@titulo varchar(100),
@repro int,
@url varchar(100)
AS
BEGIN
UPDATE video SET titulo = @titulo, repro = @repro, url = @url WHERE idVideo = @idVideo 
END
EXEC SP_video_ACTUALIZAR 2, 'Top Latino', 3, 'https://www.youtube.com/embed/85Xm5UTmbGM' 

SELECT * FROM video

CREATE PROCEDURE SP_video_ELIMINAR
@idVideo int
AS
BEGIN
DELETE FROM video WHERE idVideo = @idVideo
END
EXEC SP_video_ELIMINAR 1

CREATE PROCEDURE SP_video_MOSTRAR
AS
BEGIN
SELECT * FROM video
END
EXEC SP_video_MOSTRAR
