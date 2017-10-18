-- Сохранение вопросов пользователя.
SELECT Service$DropFunction('Question$Save');
CREATE OR REPLACE FUNCTION Question$Save(
	_question_id UUID --Идентификатор вопроса.
	, _user_id UUID --Идентификатор пользователя, задавшего вопрос.
	, _question TEXT --Вопрос.
	, _email TEXT --Email пользователя, куда отправим ответ. (Подумать, а надо ли оно, возможно, будет удалено отсюда).
	, _created_on DATE --Дата создания вопроса.
) 

RETURNS UUID
AS 
$$
	DECLARE
		new_question_id UUID;
	BEGIN
		IF (COALESCE(_question_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."question" 
			SET (user_id, question, email, created_on) 
			= (_user_id, _question, _email, _created_on) 
			WHERE question_id = _question_id;
			new_question_id = _question_id;
		ELSE
			INSERT INTO public."question" 
				(user_id, question, email, created_on) 
			VALUES (_user_id, _question, _email, _created_on)
			RETURNING question_id INTO new_question_id;
		END IF;
		
		RETURN new_question_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;