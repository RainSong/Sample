
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.ltrim = function () {
    return this.replace(/(^\s*)/g, "");
}
String.prototype.rtrim = function () {
    return this.replace(/(\s*$)/g, "");
}

function checkNotNull(value) {
    return value && value.length > 0 && value.trim().length > 0;
}

function checkLength(value, maxLength) {
    return value.length <= maxLength;
}

function checkQQ(value) {
    var parttern = /^[1-9]d{4,8}$/;
    return parttern.test(value);
}

function checkEMail(value) {
    var parttern = /^([a-zA-Z0-9]+[_|_|.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|_|.]?)*[a-zA-Z0-9]+.[a-zA-Z]{2,4}$/;
    return partten.test(value)
}

function checkIDCard(value) {

}

function checkPhone(value) {

}

function checkMobilePhone(value) {

}