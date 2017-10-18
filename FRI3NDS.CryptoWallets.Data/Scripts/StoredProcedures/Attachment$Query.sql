-- Выборка оповещения.
SELECT Service$DropFunction('Attachment$Query');
CREATE OR REPLACE FUNCTION Attachment$Query(
	_attachment_id UUID --Идентификатор вложения.
	, _document_id UUID --Идентификатор документа.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	AttachmentId UUID
	, DocumentId UUID
	, FileName TEXT
	, FileExtension TEXT
	, FilePath TEXT
	, FileSize INT
	, FileMimeType TEXT
	, CreatedOn DATE) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT a.attachment_id AS AttachmentId
			, a.document_id AS DocumentId
			, a.file_name AS FileName
			, a.file_extension AS FileExtension
			, a.file_path AS FilePath
			, a.file_size AS FileSize
			, a.file_mime_type AS FileMimeType
			, a.created_on DATE AS CreatedOn
		FROM public."attachment" a 
		WHERE (_attachment_id IS NULL OR a.attachment_id = _attachment_id)
			AND (_document_id IS NULL OR a.document_id = _document_id)
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;