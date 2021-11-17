--Необходимо подготовить запрос в результате выполнения которого выдаются следующие
--данные:
--- ФИО пользователя
--- количество заявок, созданных пользователем
--- дата создания пользователем самой первой заявки
--- дата создания пользователем последней заявки

SELECT 
    t1.name as 'ФИО пользователя',
	COUNT(t2.id_author) as 'Количество заявок, созданных пользователем',
	MIN(t2.order_create_date) as 'Дата создания пользователем самой первой заявки',
	MAX(t2.order_create_date) as 'Дата создания пользователем последней заявки'
FROM users as t1
	left join orders as t2 on t1.id_user = t2.id_author group by t1.name