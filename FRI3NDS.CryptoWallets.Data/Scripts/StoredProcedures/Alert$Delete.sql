-- Удаление оповещения.
SELECT Service$DropFunction('Alert$Delete');
CREATE OR REPLACE FUNCTION Alert$Delete(
	_id UUID --идентификатор оповещения
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."alert" WHERE alert_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;