-- Удаление регионов.
SELECT Service$DropFunction('Region$Delete');
CREATE OR REPLACE FUNCTION Region$Delete(
	_id UUID --идентификатор региона
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."region" WHERE region_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;