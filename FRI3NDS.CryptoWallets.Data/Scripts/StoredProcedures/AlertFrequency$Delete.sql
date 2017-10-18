-- Удаление типов частоты оповещений.
SELECT Service$DropFunction('AlertFrequency$Delete');
CREATE OR REPLACE FUNCTION AlertFrequency$Delete(
	_id UUID --Идентификатор частоты срабатывания оповещения.
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."alert_frequency" WHERE alert_frequency_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;