-- Удаление ЧаВо.
SELECT Service$DropFunction('Faq$Delete');
CREATE OR REPLACE FUNCTION Faq$Delete(
	_id UUID --идентификатор ЧаВо
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."faq" WHERE faq_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;