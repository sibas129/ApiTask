# ApiTask

Система представляет собой простейший пример интеграционного REST API с https://openweathermap.org/ по текущей погоде в выбранном городе. Использован API версии 3.0. Поиск погоды осуществляется по указанию наименования города. 
Ответ от  API включает поля JSON:<br/><br/>
        <br/>◦ Город<br/>
        <br/>◦ Текущее время в городе<br/>
        <br/>◦ Текущее время на сервере<br/>
       <br/>◦ Разница между временем города и на сервере<br/>
        <br/>◦ Температура в цельсиях<br/>
        <br/>◦ Давление<br/>
        <br/>◦ Влажность<br/>
        <br/>◦ Скорость ветра<br/>
       <br/> ◦ Облачность.<br/><br/><br/>
Логика отправки запросов находится в папке контроллеров, организация объектов в которые преобразуются JSON-ответы находится в папке Model. 
