using System;
using System.Collections.Generic;
using System.Text;

namespace Artificial_Intelligence_tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            String playerOne="";
            String playerTwo = "";
            int count_playerOne = 0;
            int count_playerTwo = 0;

            Console.WriteLine("Tic Tac Toe game developed using Min Max algorithm");

            while (string.IsNullOrWhiteSpace(playerOne))
            {
                Console.Write("Insert name of playerOne: ");
                playerOne = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(playerTwo))
            {
                Console.Write("Insert name of playerTwo: ");
                playerTwo = Console.ReadLine();
            }

            int[,] matrix = new int[3, 3]; //1 is max, 0 is min
            clearMatrix(matrix);
            printMatrix(matrix);

            int player = 1;
            bool _isFinished = false;
            Console.WriteLine("Waiting for setup...");

            
            while (!_isFinished)
            {
                String suggestion = calculateSuggestion(matrix, player);

                Console.WriteLine("Suggestion for {0} : {1}", player == 1 ? playerOne : playerTwo, suggestion);
                Console.Write("{0} : ", player == 1 ? playerOne : playerTwo);
                String user_step = Console.ReadLine();
                while(!isStepValid(user_step, matrix))
                
                {
                    Console.WriteLine("Invalid position!" );
                    Console.WriteLine("Suggestion for {0} : {1}", player==1 ? playerOne : playerTwo, suggestion);
                    Console.Write("{0} : ", player == 1 ? playerOne : playerTwo);

                    user_step = Console.ReadLine();
                }

                updateMatrix(user_step, matrix, player);
                printMatrix(matrix);

                (bool, int) l = isFinished(matrix);

                //no winner
                if (l.Item1) {
                    _isFinished = true;

                    if (l.Item2 == 1) { 
                        count_playerOne++;
                        Console.WriteLine("Great job {0}",playerOne);
                    }
                    if (l.Item2 == -1){
                        count_playerTwo++;
                        Console.WriteLine("Great job {0}", playerTwo);
                    }
                    if (l.Item2 == 0)
                    {
                        Console.WriteLine("No winners!");
                    }

                    Console.WriteLine("{0,5} : {1,5}\n{2,5} : {3,5}", playerOne, count_playerOne, playerTwo, count_playerTwo);
                    String answer = "";
                    while (!answer.Equals("y") && !answer.Equals("Y") && !answer.Equals("n") && !answer.Equals("N"))
                    {
                        Console.WriteLine("Another game?[y]\\[n]  ");
                        answer = Console.ReadLine();
                    }
                    if(answer.Equals("y") || answer.Equals("Y"))
                    {
                        _isFinished = false;
                        clearMatrix(matrix);
                        printMatrix(matrix);
                        Console.WriteLine("Waiting for setup...&...cleaning matrix");
                        player *= (-1);
                    }
                    else
                    {
                        Console.WriteLine("Thank you!\n");
                        Console.ReadLine();
                    }


                }

                player *= (-1);
            }




        }

        static (bool, int) isFinished(int[,] matrix)
        {
            int i = 0;
            int j = 0;

            //horizontal tris
            for (; i < 3; i++)
                if (matrix[i, j] == matrix[i, j + 1] && matrix[i, j] == matrix[i, j + 2] && matrix[i, j]!=0)
                    return (true, matrix[i, j]);

            //vertical tris
            i = 0;
            for (j = 0; j < 3; j++)
                if (matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 2, j] && matrix[i, j] != 0)
                    return (true, matrix[i, j]);

            //diagonal tris Left->
            if (matrix[0, 0] == matrix[1, 1] && matrix[0, 0] == matrix[2, 2] && matrix[0, 0] != 0)
                return (true, matrix[1, 1]);

            //diagonal tris Right->
            if (matrix[0, 2] == matrix[1, 1] && matrix[0, 2] == matrix[2, 0] && matrix[0, 2] != 0)
                return (true, matrix[1, 1]);

            //no winner
            return (freePosition(matrix)==0,0);
        }

        static void updateMatrix(String user_step, int[,] matrix, int value)
        {
            int _c1 = user_step[0] - 97;
            int _c2 = user_step[1] - 65;

            matrix[_c1, _c2] = value;
        }

        static bool isStepValid(String user_step, int[,] matrix)
        {
            if (user_step.Length != 2)
                return false;

            int _c1 = user_step[0] - 97;
            int _c2 = user_step[1] - 65;

            if (_c1 > 2 || _c1 < 0 || _c2 > 2 || _c2 < 0)
                return false;

            if(matrix[_c1,_c2]==0)
                return true;

            return false;
        }

        static void clearMatrix(int[,] matrix)
        {
            int i = 0;
            int j = 0;
            for (; i < 3; i++)
                for (j = 0; j < 3; j++)
                    matrix[i, j] = 0;
        }

        static void printMatrix(int[,] matrix)
        {

            Console.WriteLine("\t{0}\t{1}\t{2}", "A", "B", "C\n");
            int i = 0;
            int j = 0;
            for (; i < 3; i++) {
                Console.Write((char)(97 + i)+" ");
                int x = matrix[i, 0];
                if (x == 1)
                    x = 88;
                if (x == -1)
                    x = 79;

                int y = matrix[i, 1];
                if (y == 1)
                    y = 88;
                if (y == -1)
                    y = 79;

                int z = matrix[i, 2];
                if (z == 1)
                    z = 88;
                if (z == -1)
                    z = 79;
                Console.Write("\t{0}\t{1}\t{2}", (char)x, (char)y, (char)z);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static String calculateSuggestion(int[,] matrix, int player)
        {
            TreeNode root = new TreeNode(matrix);
            root.player = player;
            Queue<TreeNode> fringe = new Queue<TreeNode>();
            int branching_factor = freePosition(matrix);


            //create n children as freePosition
            for (int i = 0; i < branching_factor; i++)
            {
                int[,] matrix_tmp = new int[3, 3];
                copyMatrix(matrix,matrix_tmp);
                TreeNode tmp = new TreeNode(matrix_tmp);
                tmp.Parent = root;
                tmp.player = player*(-1);
                tmp.step = createStep(matrix_tmp, root.player, i);
                tmp.branching_f = branching_factor - 1;
                root.AddChild(tmp);
                fringe.Enqueue(tmp);
            }

            //create tree min-max
            while (fringe.Count!=0)
            {
                TreeNode tmp_node = fringe.Dequeue();
                //if it is not a final state
                if (!isFinished(tmp_node.matrix).Item1) { 
                    //take the branch
                    for (int i = 0; i < tmp_node.branching_f; i++)
                    {
                        //create the step of every child
                        int[,] matrix_tmp = new int[3, 3];
                        copyMatrix(tmp_node.matrix, matrix_tmp);
                        TreeNode tmp = new TreeNode(matrix_tmp);
                        tmp.step= createStep(matrix_tmp, tmp_node.player, i);
                        tmp.Parent = tmp_node;
                        tmp.branching_f = tmp_node.branching_f - 1;
                        tmp_node.AddChild(tmp);
                        if (tmp_node.player == 1)
                            tmp.player = -1;
                        else
                            tmp.player = 1;
                        fringe.Enqueue(tmp);
                    }
                }
            }

            //take the frontier and expand the eval to the root
            List<TreeNode> frontier = root.getFrontier();
            foreach (TreeNode node in frontier)
            {
                node.eval=node.evaluate();
            }
            
            foreach (TreeNode node in frontier)
            {
                TreeNode tmpscan = node;
                while (tmpscan.Parent != null)
                {
                    tmpscan = tmpscan.Parent;

                    if (tmpscan.player == 1) {
                        (String, int) l = tmpscan.getMaxFromChildren();
                        //tmpscan.step = l.Item1;
                        tmpscan.eval = l.Item2;

                    }
                    else
                    {
                        (String, int) l = tmpscan.getMinFromChildren();
                        //tmpscan.step = l.Item1;
                        tmpscan.eval = l.Item2;
                    }
                }
            }

            if (root.player == 1)
            {
                    (String, int) l = root.getMaxFromChildren();
                    root.step = l.Item1;
                    root.eval = l.Item2;

            }
            else
            {
                (String, int) l = root.getMinFromChildren();
                root.step = l.Item1;
                root.eval = l.Item2;

            }
            return root.step;


        }

        static int freePosition(int[,] matrix)
        {
            int count = 0;
            int i = 0;
            int j = 0;
            for (; i < 3; i++)
                for (j = 0; j < 3; j++)
                    if (matrix[i, j] == 0)
                        count++;
            return count;
        }

        static void copyMatrix(int[,] from, int[,] to)
        {
            int i = 0;
            int j = 0;
            for (; i < 3; i++)
                for (j = 0; j < 3; j++)
                        to[i, j] = from[i, j];
        }

        static String createStep(int[,] matrix, int player, int step)
        {
            int count = 0;
            int i = 0;
            int j = 0;
            for (; i < 3; i++)
                for (j = 0; j < 3; j++)
                    if (matrix[i, j] == 0) {
                        if (step == count) { 
                            matrix[i, j] = player;
                            StringBuilder sb = new StringBuilder();
                            sb.Append((char)(97 + i)).Append((char)(65 + j));
                            return sb.ToString();
                        }
                        count++;
                    }
            return "none";
        }
    }

}
