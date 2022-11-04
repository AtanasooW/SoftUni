function func(){
    String.prototype.ensureStart = function(str){
        let result = "";
        if(!this.startsWith(str)){
            result = str + this;
        }
        else{
            result = this
        }
        return result;
    }
    String.prototype.ensureEnd = function(str){
        let result = "";
        if (!this.endsWith(str)) {
            result = this + str
        }
        else{
            result = this
        }
        return result;
    }
    String.prototype.isEmpty = function(){
        if(this.length < 1){
            return true;
        }
        return false;
    }
    String.prototype.truncate = function (n){

    }
}