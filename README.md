# Опис на проектната задача по Визуелно Програмирање

Во нашата проектна задача е изработена апликација чија цел е да се менаџираат информациите за вработени и нивните плати во повеќе фирма. Како што може да се види од самиот старт на апликацијата, таа се состои од една форма и 3 различни табови на таа форма.

## Главна форма

* **Првиот таб** се состои од 17 полиња кои што се задолжителни за да се 
регистрира фирмата. Откако ќе се пополнат полињата, со притискање на копчето зачувај доколку сите внесени податоци се во валиден формат во нашата база на податоци во соодветната табела за зачувуваат тековните податоци. Доколку пак сакаме да направиме некаква измена во некоја веќе постоечка фирма тогаш од dropdown листата што се наоѓа горе лево во формата ја избираме саканата фирма и со притискање на копчето одбери полињата се пополнуваат за податоците за одбраната фирма. Откако ќе ги измениме податоците, со притискање на копчето зачувај се ажурира избраната фирма.

![alt text](https://i.ibb.co/5BkbJKL/slika1.png)

* **Вториот таб** е наменет за внесување на податоците за вработените. Горе лево од dropdown листата ја селектираме саканата фирма и со клик на копчето одбери list boxot од лева се пополнува со сите внесени вработени за таа фирма. Доколку сакаме да до дадаме нов вработен во одбраната фирма, тогаш прво треба да го притиснеме копчето Исчисти кое што ќе ги изпразни сите полиња во формата, а после треба полињата да ги исполниме со податоците за новиот вработен. Зачувувањето се прави со притискање на копчето Зачувај доле десно, доколку помине валидацијата вработениот ќе биде зачуван во базата на податоци. За промена на податоците за некој од веќе постоечки вработен само се селектира во list boxot, се притиска копчето Одбери и полињата се исполнуваат со неговите податоци. При промена на потребните полиња само се притиска копчето Зачувај. 

![alt text](https://i.ibb.co/Q92fGXr/slika2.png)

* **Третиот таб** е наменет за за преглед на платата на одреден вработен и за сите придонеси кои што произлегуваат од неговата бруто плата. Чекорите се исти како и во минатите табови. Од првата dropdown листа се селектира фирмата, а од втората dropdown листа се селектира вработениот и полињата ни се пополнуваат со соодветните информации.
* Со клик на копчето Генерирај ќе ни се генерира текстуална датотека во фолдерот “Извештаи” со основните податоци за фирмата, како и основните податоци и трошковите што фирмата ги има за нејзините вработени (Име,Датум на преим, ЕМБГ, Трансакциска сметка, бруто плата) за претходно селектираниот месец. Пред да ја генерираме датотеката имаме опција Преглед која што ќе ни го генерира и прикаже текстот што ќе ни се зачува во датотеката во text boxot што се наоѓа доле десно.


![alt text](https://i.ibb.co/nc1kzct/slika3.png)

## Структура на проектот
* Модел **Firma.cs** кој што се состои од сите податоци што ни требаат за зачувување на една фирма
* Модел **Vraboten.cs** што се состои од сите податоци за еден вработен
* Контролер **FirmaController.cs** кој што ни служи за ажурирање на податоците во базата за табелата за Фирми.
* Контролер **VrabotenController.cs** кој што ни служи за ажурирање на податоците во базата за табелата за Вработени.
* **DataContext.cs** кој што ни служи за комуникација зо базата на податоци.
* **Form1.cs** главната форма која што е опишана погоре.
