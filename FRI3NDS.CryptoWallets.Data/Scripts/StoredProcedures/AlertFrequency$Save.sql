-- Сохранение типов частоты оповещений.
SELECT Service$DropFunction('AlertFrequency$Save');
CREATE OR REPLACE FUNCTION AlertFrequency$Save(
	_alert_frequency_id INT --Идентификатор частоты срабатывания оповещения.
	, _name TEXT --Название.
) 
RETURNS INT
AS 
$$
	DECLARE
		new_alert_frequency_id INT;
	BEGIN
	
		IF (_alert_frequency_id > 0) THEN
			UPDATE public."alert_frequency" 
			SET (name) 
			= (_name) 
			WHERE alert_frequency_id = _alert_frequency_id;
			new_alert_frequency_id = _alert_frequency_id;
		ELSE
			INSERT INTO public."alert_frequency" 
				(name) 
			VALUES (_name)
			RETURNING alert_frequency_id INTO new_alert_frequency_id;
		END IF;
		
		RETURN new_alert_frequency_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;