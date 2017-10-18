-- Удаление стран.
SELECT Service$DropFunction('Country$Delete');
CREATE OR REPLACE FUNCTION Country$Delete(
	_id UUID --идентификатор страны
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."country" WHERE country_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;