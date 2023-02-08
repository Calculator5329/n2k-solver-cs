using System;

namespace secondProject  {
    internal class Program {
        const int ExpoLimit = 10;
        static void Main(string[] args) {

            int[] dice = new int[3];
            double answer;
            
            int[] expo = {0, 0, 0};
            int[] op = {0, 0};

            Console.Write("Enter the first dice roll: ");
            
            dice[0] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second dice roll: ");
            
            dice[1] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the third dice roll: ");
            
            dice[2] = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the board number you want to solve: ");
            answer = Convert.ToDouble(Console.ReadLine());

            // We can change expo1-3 from 0 - 10 and op1-2 from 0-3
            // Iterate through exponents first
            for(int i = 0; i < Math.Pow(ExpoLimit, 3); i++) {
                // The first exponent is the value in the ones place (of i)
                expo[0] = i % 10;

                // The second exponent is the value in the tens place (of i)
                expo[1] = (i % 100 - 5) / 10;

                // The first exponent is the value in the hundreds place (of i)
                expo[2] = i / 100;

                // Now iterate through different values for op1
                for(int j = 0; j < 4; j++) {
                    op[0] = j;

                    // Now iterate through different values for op2
                    for(int k = 0; k < 4; k++) {
                        op[1] = k;
                        
                        if(calcEquation(dice[0], dice[1], dice[2], op[0], op[1], expo[0], expo[1], expo[2]) == answer) {
                            Console.WriteLine(eqToString(dice[0], dice[1], dice[2], op[0], op[1], expo[0], expo[1], expo[2], answer));
                        }
                    }
                }
            }

            Console.Write("Done! Press enter to exit program");
            Console.ReadLine();

        }
        static double calcEquation(int dice1, int dice2, int dice3, int op1, int op2, int expo1, int expo2, int expo3) {
            double result, firstCalc;

            double val1 = Math.Pow(dice1, expo1);
            double val2 = Math.Pow(dice2, expo2);
            double val3 = Math.Pow(dice3, expo3);

            // Switch the order of the equation arond if op2 comes first in order of operations
            if(op2 >= 2 && op1 <= 1) {
                firstCalc = opCalc(val2, val3, op2);
                result = opCalc(val1, firstCalc, op1);
            }
            else {
                firstCalc = opCalc(val1, val2, op1);
                result = opCalc(firstCalc, val3, op2);
            }

            return result;

        }

        static double opCalc(double num1, double num2, int op) {
            switch(op) {
                case 0:
                    return num1 + num2;
                case 1:
                    return num1 - num2;
                case 2:
                    return num1 * num2;
                case 3:
                    return num1 / num2;
                default:
                    return -1;
            }
                        
        }

        static string eqToString(int dice1, int dice2, int dice3, int op1, int op2, int expo1, int expo2, int expo3, double answer) {
            string eqString = dice1 + "^" + expo1 + " " + opString(op1) + " " +
                              dice2 + "^" + expo2 + " " + opString(op2) + " " + 
                              dice3 + "^" + expo3 + " = " + answer;
            return eqString;
        }
        static string opString(int op) {
            switch(op) {
                case 0:
                    return "+";
                case 1:
                    return "-";
                case 2:
                    return "*";
                case 3:
                    return "/";
                default:
                    return "err";
            }
        }

        static int opInt(string op) {
            switch(op) {
                case "+":
                    return 0;
                case "-":
                    return 1;
                case "*":
                    return 2;
                case "/":
                    return 3;
                default:
                    return -1;
            }
        }

    }
}

