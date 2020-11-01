grammar CalculatorBNF;


/*
 * Parser Rules
 */

compileUnit : expression EOF;

expression :
    LPAREN expression RPAREN #ParenthesizedExpr
    | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
    | expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
    | expression operatorToken=(MOD | DIV) expression #ModDivExpr
    | operatorToken=(ADD | SUBTRACT) expression #UnaryExpr
    | expression operatorToken=(EQUALS | MOREOP | LESSOP) expression #BoolExpr
    | NOT expression #NotExpr
    | NUMBER #NumberExpr
    | IDENTIFIER #IdentifierExpr
    ; 

/*
 * Lexer Rules
 */

NUMBER : INT ('.' INT)?; 
IDENTIFIER : [A-Z]+[1-9][0-9]*;
INT : ('0'..'9')+;

NOT: 'not';
DIV: 'div';
MOD: 'mod';
MOREOP: '>';
LESSOP: '<';
EQUALS: '=';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';

WS : [ \t\r\n] -> channel(HIDDEN);
