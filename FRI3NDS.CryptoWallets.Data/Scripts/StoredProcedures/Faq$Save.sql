-- Сохранение ЧаВо.
SELECT Service$DropFunction('Faq$Save');
CREATE OR REPLACE FUNCTION Faq$Save(
	_faq_id UUID --Идентификатор ЧаВо.
	, _question TEXT --Вопрос.
	, _answer TEXT --Ответ.
	, _created_on DATE --Дата создания ЧаВо.
) 

RETURNS UUID
AS 
$$
	DECLARE
		new_faq_id UUID;
	BEGIN
		IF (COALESCE(_faq_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."faq" 
			SET (question, answer, created_on) 
			= (_question, _answer, _created_on) 
			WHERE faq_id = _faq_id;
			new_faq_id = _faq_id;
		ELSE
			INSERT INTO public."faq" 
				(question, answer, created_on) 
			VALUES (_question, _answer, _created_on)
			RETURNING faq_id INTO new_faq_id;
		END IF;
		
		RETURN new_faq_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;