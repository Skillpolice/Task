function Purchase(name,price,count){
    this.name=name;
    this.price=price;
    this.count=count;
}
    Purchase.prototype.getCost=function(){
        return (this.price*this.count);
    }
    Purchase.prototype.toString=function(){
        return  (this.name + ";" + this.price.toFixed(2) + ";" + this.count + ";" + this.getCost().toFixed(2));
    }

function DiscountPurchase(name,price, count){
   Purchase.apply(this,arguments);
}
var fixDiscount=0.45;
DiscountPurchase.prototype=Object.create(Purchase.prototype);
DiscountPurchase.prototype.constructor=DiscountPurchase;
DiscountPurchase.prototype.getCost=function(){
    return (Purchase.prototype.getCost.apply(this)-fixDiscount);
}
DiscountPurchase.prototype.toString=function(){
    return Purchase.prototype.toString.apply(this);
}
var makeS=function(purch){
    var totalCost=0;
    return function(purch){
        if(purch!=undefined){
            return totalCost+=purch.getCost();
        }
        else{
            return totalCost;
        }
    }
}

var purch=[];
purch[0] = new Purchase("Xiaomi", 7.23, 3);
purch[1] = new Purchase("Apple", 2.41, 5);
purch[2] = new Purchase("Samsung", 2.5, 3);
purch[3] = new Purchase("Oppo", 2.69, 6);
purch[4] = new Purchase("HTC", 3.72, 3);
purch[5] = new DiscountPurchase("Huawei", 2.50, 4, 15);
purch[6] = new DiscountPurchase("ASUS", 1.10, 3, 10);
purch[7] = new DiscountPurchase("Lenovo", 1.12, 2, 5);
purch[8] = new DiscountPurchase("LG", 3.50, 2, 12);
for(var i=0;i<purch.length;i++){
    document.writeln(purch[i] +"<br>");
}

var m=makeS();
for(var i=0;i<purch.length;i++){
   m(purch[i]);
}
document.writeln("<br>"+"Total cost: "+m()+" BYN ");


