-- Удаление городов.
SELECT Service$DropFunction('City$Delete');
CREATE OR REPLACE FUNCTION City$Delete(
	_id UUID --идентификатор города
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."city" WHERE city_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;