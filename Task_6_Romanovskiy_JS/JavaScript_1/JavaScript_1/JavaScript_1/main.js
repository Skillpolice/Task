class Purchase{
    constructor(name,price,count){
            this.name=name;
            this.price=price;
            this.count=count;
    }
    getCost(){
      return  this.price*this.count;
    }
    toString(){
        return this.name+";"+this.price.toFixed(2)+" BYN"+";"+this.count+";"+"total cost: "+this.getCost().toFixed(2)+" BYN";
    }
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
purch[0]= new Purchase("Xiaomi",7.23,3);
purch[1]= new Purchase("Apple",2.41,5);
purch[2]=new Purchase("Samsung",2.5,3);
purch[3]=new Purchase("Oppo",2.69,6);
purch[4]=new Purchase("HTC",3.72,3);
for(var i=0;i<purch.length;i++){
    document.writeln(purch[i] +"<br>");
}

var m=makeS();
for(var i=0;i<purch.length;i++){
   m(purch[i]);
}
document.writeln("<br>"+"Total cost: "+m().toFixed(2)+" BYN");
