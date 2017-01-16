function sayHi(name) {
    console.log(typeof name);
    console.log(name);
    return "Hello ${name}" + name;
}

var ss = sayHi("Jingjing");

String.prototype.TrimTest = function () { return this + "1"; };
console.log(ss.TrimTest());