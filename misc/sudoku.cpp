#include<iostream>

typedef int16 short;

class Sudoku{
 public:
  Sudoku();
  // Sudoku(istream); // algo asi...
  int solve();
 private:
  int16 sudoku[81]; // ?
  int16 col[9];
  int16 row[9];
  int16 box[9];

 /* Digamos que para cada casilla en el sudoku
  * si esta ocupada entonces habra un bit que lo indique
  * luego si no esta ocupada las posibilidades de esa casilla i
  * estan dadas por (col(i) = i mod 9, row(i) = i div 9 y
  * box(i) = col div 3 + ((row div 3) * 3)
  * ~( col(i) | row(i) | box(i) ) , es decir el complemento
  * de el conjunto de opciones ya tomadas.*/

 int16 col(int i){
  return col[i%9];
 }
 int16 row(int i){
  return row[i/9];
 }
 int16 box(int i){
  return box[(i%9) + ((i/9)*3)];
 }

 /* Para cada casilla vacia:
  *  Si solo tiene una posibilidad colocarla y actualizar posibilidades
  *  de lo contrario pasar por todas las casillas de la columna|fila|caja y
  *  si esta casilla tiene una posibilidad que no existe en ninguna otra
  *  entonces colocar ahi dicha opcion
  *  Si ninguna de estas condiciones se cumple entonces pasar a otra casilla
  *  */

}
