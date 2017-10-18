-- Выборка вопросов пользователя.
SELECT Service$DropFunction('Question$Query');
CREATE OR REPLACE FUNCTION Question$Query(
	_question_id UUID --Идентификатор вопроса.
	_user_id UUID --Идентификатор пользователя.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	QuestionId UUID
	, UserId UUID
	, Question TEXT
	, Email TEXT
	, CreatedOn DATE) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT q.question_id AS QuestionId
			, q.user_id AS UserId
			, q.question AS Question
			, q.email AS Email
			, q.created_on AS CreatedOn
		FROM public."question" q 
		WHERE (_question_id IS NULL OR q.question_id = _question_id)
			AND (_user_id IS NULL OR q.user_id = _user_id) 
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;