function solve(args) {

    function getPoints(row, col) {
        return Math.pow(2, row) - col;
    }

    // testing the function getPoints()
    //console.log(getPoints(0,0));
    //console.log(getPoints(2,1));
    //console.log(getPoints(1,4));

    // ф-я, получаваща стринг и връща масив с редовете и колоните, к. имам
    function getRowsAndCols(str) {
        var parts = str.split(' '); // разделяме по интервал
        // и получаваме 2 подстринга - parts[0] и parts[1]
        // парсваме ги към цели числа
        // и връщаме масив с 0лев елемент броя редове и 1-ви ел-т броя колони
        return [parseInt(parts[0]), parseInt(parts[1])];
    }

    // testing
    //console.log(getRowsAndCols('3 5'));
    //console.log(getRowsAndCols('123 1234'));

    // ф-я, к.да ми даде ст-та по rol и col от входните данни
    function getValue(params, row, col) {
        return params[row + 1][col];
    }

    var rowsAndCols = getRowsAndCols(args[0]),    // в params[0] се намира стринга, съдържащ редовете и колоните
        rows = rowsAndCols[0],
        cols = rowsAndCols[1],
    // You start always at bottom-right  cell (row-1, col-1).
        row = rows - 1, // текущият ред = бр.редове - 1
        col = cols - 1, // текущата колона = бр.колони - 1
        points = 0,
        moves = 0,    // колко пъти сме стъпили върху дад.клетка
        used = [];

    // скоковете могат да се направят и с if-ове, но по-лесно е:
    // декларираме си в една променлива всички възможни индексирани от 0 движения на коня
    // правим масив с 8 ел-та, всеки от които казва
    // от тек.позиция колко местя реда и колоната
    var horseMoves = [[-2, 1], [-1, 2], [1, 2], [2, 1],       // 1=> 2 реда нагоре, 1 колона надясно; 2=> 1 ред нагоре, 2 колони надясно и т.н.
        [2, -1], [1, -2], [-1, -2], [-2, -1]];

    while (true) {
        // проверка за стъпване извън рамките на масива
        if (row < 0 || row >= rows          // ако текущият ред <0 или >= бр.редове
            || col < 0 || col >= cols) {
            console.log('Go go Horsy! Collected ' + points + ' weeds');
            break;
        }

        // проверка за стъпване на клетка, в к. вече сме били (циклене)
        if (used[row + ' ' + col]) {
            console.log('Sadly the horse is doomed in ' + moves + ' jumps');
            break;
        }

        moves = moves + 1;
        points = points + getPoints(row, col);

        // преход към следващата клетка
        // ако ст-та е 8 => искаме 7мия ел-т
        var move = horseMoves[getValue(args, row, col) - 1];   // ст-та на клетката в момента

        // трябва да маркираме клетката, в к. вече сме били
        used[row + ' ' + col] = true;   // масивът може да е с произволен индекс "row col"

        // в move[0] получавам с колко трябва да преместя X
        row += move[0];
        // в move[1] получавам с колко трябва да преместя Y
        col += move[1];
    }
}

solve(['3 5', '54561', '43328', '52388']);
console.log('Go go Horsy! Collected 1 weeds');

solve(['3 5', '54361', '43326', '52188']);
console.log('Sadly the horse is doomed in 7 jumps');