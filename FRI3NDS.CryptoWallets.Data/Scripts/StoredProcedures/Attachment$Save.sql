-- Сохранение оповещения.
SELECT Service$DropFunction('Attachment$Save');
CREATE OR REPLACE FUNCTION Attachment$Save(
	_attachment_id UUID --Идентификатор вложения.
	, _document_id UUID --Идентификатор документа.
	, _file_name TEXT --Название файла.
	, _file_extension TEXT --Расширение файла.
	, _file_path TEXT -- Путь к файлу в файловой системе.
	, _file_size INT --Размер файла в байтах.
	, _file_mime_type TEXT --Майм-тип файла.
	, _created_on DATE --Дата создания вложения.
) 

RETURNS UUID
AS 
$$
	DECLARE
		new_attachment_id UUID;
	BEGIN
		IF (COALESCE(_attachment_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."attachment" 
			SET (document_id, file_name, file_extension, file_path, file_size, file_mime_type, created_on) 
			= (_document_id, _file_name, _file_extension, _file_path, _file_size, _file_mime_type, _created_on) 
			WHERE attachment_id = _attachment_id;
			new_attachment_id = _attachment_id;
		ELSE
			INSERT INTO public."attachment" 
				(document_id, file_name, file_extension, file_path, file_size, file_mime_type, created_on) 
			VALUES (_document_id, _file_name, _file_extension, _file_path, _file_size, _file_mime_type, _created_on)
			RETURNING attachment_id INTO new_attachment_id;
		END IF;
		
		RETURN new_attachment_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;