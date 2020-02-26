//Класс-покупка товара
function Purchase (name,price,quantity){
    this.Name=name;
    this.Price=price;
    this.Quantyti=quantity;
}
//Метод, определяющий стоимость
Purchase.prototype.getCost = function (){
    return (this.Price* this.Quantyti);
}
//Переопределяю ToString() 
//хранящийся в прототипе
Purchase.prototype.toString = function(){
    return (this.Name+";"+this.Price.toFixed(2)+";"+this.Quantyti+";"+this.getCost().toFixed(2));
}

//класс- покупка с фиксированной скидкой от цены
function PurchasePriceDiscont(name,price,quantity,priceDiscont){
    Purchase.call(this,name,price,quantity);
    this.PriceDiscont= priceDiscont;
}
PurchasePriceDiscont.prototype =Object.create(Purchase.prototype);
PurchasePriceDiscont.prototype.constructor = PurchasePriceDiscont;

//Метод, определяющий стоимость
PurchasePriceDiscont.prototype.getCost=function(){
    return (Purchase.prototype.getCost.call(this)-this.PriceDiscont);
}

//Переопределяю ToString() 
//хранящийся в прототипе
PurchasePriceDiscont.prototype.toString = function(){
    return (Purchase.prototype.toString.call(this)+";"+this.PriceDiscont.toFixed(2));
}

//класс - покупка со скидкой в процентах
function PurchasePersentDiskont (name,price,quantity,persentDiscont){
    //наследую от purchase
    Purchase.call(this,name,price,quantity);
    this.PersentDiscont=persentDiscont;
    //перезаписываю геткост
    //копирую метод родителя
    var parentGetCost=Purchase.prototype.getCost;
    this.getCost= function (){
        return (parentGetCost.call(this)*(100-this.PersentDiscont)/100);
    }

    //переопределяю tostring
    //копирую родительский
    var parentToString = Purchase.prototype.toString;
    this.toString = function (){
        return (parentToString.call(this)+";"+this.PersentDiscont);
    }
}

//функция, определяющая итоговую стоимость
function MakeS(purchse) {
    var totalCoast=0;
    return function(purchse){
        //return (purchse!=undefined)?(totalCoast+=purchse.getCost()):(totalCoast);
        if (purchse!=undefined) {
            return totalCoast+=purchse.getCost();
        }
        else {
            return totalCoast;
        }
    } 
}

//Создаю массив с покпками
var PurchaseArray=[];
PurchaseArray.push( new Purchase("Xiaomi",2.59,2));
PurchaseArray.push( new Purchase("Apple",8.9,1));
PurchaseArray.push( new Purchase("Oppo",2.15,2));
PurchaseArray.push( new Purchase("HTC",3.2,2));
PurchaseArray.push(new PurchasePriceDiscont("Xiaomi",2.59,2,0.5));
PurchaseArray.push(new PurchasePriceDiscont("Apple",80.9,1,0.5));
PurchaseArray.push(new PurchasePriceDiscont("Oppo",2.15,2,0.5));
PurchaseArray.push(new PurchasePriceDiscont("HTC",3.2,2,0.5));
PurchaseArray.push(new PurchasePersentDiskont("Xiaomi",2.59,2,20));
PurchaseArray.push(new PurchasePersentDiskont("Apple",8.9,1,20));
PurchaseArray.push(new PurchasePersentDiskont("Oppo",20.15,2,20));
PurchaseArray.push(new PurchasePersentDiskont("HTC",3.2,2,20));


var makeS = MakeS();
document.writeln("<h3> PurchaseArray: </h3>")
//вывод массива в браузер
PurchaseArray.forEach(element => {
    document.writeln(element+"<br>");
    makeS(element);
});

document.writeln("<h3> TotalCoast: " + makeS().toFixed(2) + "</h3>" +"<br>");

//создаю новый массив в котором
//стомость покупок >20
var newPurchaseArray = PurchaseArray.filter(purch=>{
    return (purch.getCost()>20);
})
//вывожу на экран новый массив
document.writeln("<h3> NewPurchaseArray(getCost>20): " + "</h3>" );
newPurchaseArray.forEach(element => {
    document.writeln(element+"<br>");
});

//4 С помощью метода массива map() 
//получить новый массив покупок из исходного, 
//при этом покупки без скидок (базового класса), 
//должны замениться покупками со скидкой в процентах, 
//где процент скидки численно равен удвоенному количеству товара. 
var newPurchasWithDiscontArray = PurchaseArray.map(element=>{
    if (!("PriceDiscont" in element) && !("PersentDiscont" in element)) {
        return new PurchasePersentDiskont(element.Name,element.Price,element.Quantyti,element.Quantyti*2);
    }
    else {
        return element;
    }
})
//вывожу на экран новый массив
document.writeln("<h3> NewnewPurchasWithDiscontArray(elements only whith discont): " + "</h3>" );
newPurchasWithDiscontArray.forEach(element => {
    document.writeln(element+"<br>");
});

//Проверка, является ли стоимость всех покупок большей 50
document.writeln("<h3> Is the coast of every elemen  more then 50? " + "</h3>" );
document.writeln("Answer: "+PurchaseArray.every(element=>{return element.getCost()>50}));

//проверка является ли стоимость какой-нибудь покупки большей 50
document.writeln("<h3> Is the coast of some elemen  more then 50? " + "</h3>" );
document.writeln("Answer: "+PurchaseArray.some(element=>{return element.getCost()>50}));

//нахожу покупку с максимальной стоимостью
document.writeln("<h3> Purchase whis max coast:" + "</h3>" );
var maxAlement =  PurchaseArray.reduce(function(maxPurchase,element){
    return (maxPurchase.getCost()<element.getCost())?(element):(maxPurchase);
})
document.writeln(maxAlement+"<br>");
 
var newPurchase = new Purchase(PurchaseArray[0].Name,PurchaseArray[0].Price,PurchaseArray[0].Quantyti);
document.writeln("<h3> New Purchase with longest name, max price and min quantity:</h3>");
newPurchase=PurchaseArray.reduceRight(function(purch,element){
    
    if (purch.Name<element.Name){
        purch.Name=element.Name;
       
    }
    if (purch.Price<element.Price){
        purch.Price=element.Price;
       
    }
    if (purch.Quantyti>element.Quantyti){
        purch.Quantyti=element.Quantyti;
       
    }
    return purch;
},newPurchase);
document.writeln(newPurchase);