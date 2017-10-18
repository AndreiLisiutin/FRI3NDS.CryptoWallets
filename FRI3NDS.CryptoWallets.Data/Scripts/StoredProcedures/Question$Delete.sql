-- Удаление вопросов пользователя.
SELECT Service$DropFunction('Question$Delete');
CREATE OR REPLACE FUNCTION Question$Delete(
	_id UUID --идентификатор вопроса
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."question" WHERE question_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;