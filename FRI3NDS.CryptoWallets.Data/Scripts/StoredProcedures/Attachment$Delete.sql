-- Удаление вложения.
SELECT Service$DropFunction('Attachment$Delete');
CREATE OR REPLACE FUNCTION Attachment$Delete(
	_id UUID --Идентификатор вложения.
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."attachment" WHERE attachment_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;