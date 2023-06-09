# Практическая работа №2
# Builder_Decorator_Observer_patterns
## Builder
Суть паттерна Строитель заключается в создании сложного объекта шаг за шагом без необходимости знать все его детали конструктора.
В данной программе паттерн Строитель применяется с использованием классов TaskBuilder и Task.
Класс TaskBuilder предоставляет методы SetDescription и SetStatus, которые позволяют установить описание и статус задачи пошагово.
После установки всех необходимых атрибутов, метод GetTask возвращает готовый объект задачи типа Task.
Это позволяет создавать задачи с разными атрибутами без необходимости использовать длинный конструктор с большим количеством параметров.
## Decorator
Паттерн Декоратор позволяет динамически добавлять новую функциональность к объекту, оборачивая его в декораторы без изменения его основной структуры.
В данной программе паттерн Декоратор применяется с использованием классов TaskDecorator, PriorityTaskDecorator и Task.
Интерфейс ITask представляет базовый объект задачи, а класс Task является конкретной реализацией этого интерфейса.
Класс TaskDecorator является базовым классом декоратора и также реализует интерфейс ITask. Он содержит ссылку на декорируемый объект типа ITask.
Класс PriorityTaskDecorator является конкретным декоратором и добавляет функциональность приоритета к задаче. Он наследуется от TaskDecorator и переопределяет метод GetDescription, добавляя информацию о приоритете к описанию задачи.
Это позволяет добавлять новую функциональность к объекту задачи (например, приоритет), оборачивая его в декораторы, не изменяя базовый класс Task.
## Observer
Паттерн Наблюдатель используется для установления связи между объектами, таким образом, что изменение состояния одного объекта приводит к автоматическому оповещению и обновлению других зависимых объектов.
В данной программе паттерн Наблюдатель применяется с использованием интерфейсов ITaskObserver и ITask, а также классов Task и TaskStatusObserver.
Интерфейс ITaskObserver определяет метод Update, который вызывается при изменении задачи.
Класс Task представляет наблюдаемый объект, который содержит список наблюдателей (_observers) и методы для добавления/удаления наблюдателей и оповещения их об изменениях.
Класс TaskStatusObserver является конкретным наблюдателем, реализующим интерфейс ITaskObserver и определяющим логику обработки изменений статуса задачи.
Когда происходят изменения в задаче, метод Notify в наблюдаемом объекте Task вызывает метод Update у всех своих наблюдателей, чтобы они могли обновиться соответственно.

![nLFDQiCm3BxhANpqA7c17aOfWR7J1kqUm8lL8PR5GL8APTkxhtPIjoufRAVvObi_twTFibUYZdNuQ06eK-ITQz0yRfsyhmTgFRBv17DSYmrgZT8mzKgXi_vyNXfHfkxjpYpDFf3FyHjrEeYLjCr7FQ16BXkjyG3V04thHDBjn7r1R4uu4ql2lZBM97th3ZPJ5Q2bhaeZpqJ-Rq9hR08x3R](https://github.com/Ivan-ee/Ivan-ee-Builder_Decorator_Observer_patterns/assets/89241345/bb5754d1-8194-44a0-bf23-4d99cb115ab5)
