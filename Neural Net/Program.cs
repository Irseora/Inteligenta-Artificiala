namespace Neural_Net
{
    internal class Program
    {
        public const int NumInputs = 2;
        public const int NumOutputs = 1;
        public const int NumHiddenNodes = 2;
        public const int NumTrainingSets = 4;

        static Random random = new Random();

        // -----------------------------------------------------

        static void Main(string[] args)
        {
            // Learning rate / step size
            const double learningRate = 0.1f;

            // Hidden & output layer arrays
            double[] hiddenLayer = new double[NumHiddenNodes];
            double[] outputLayer = new double[NumOutputs];

            // Biases
            double[] hiddenLayerBias = new double[NumHiddenNodes];
            double[] outputLayerBias = new double[NumOutputs];

            // Weights
            double[,] hiddenWeights = new double[NumInputs, NumHiddenNodes]; // input -> hiddenLayer
            double[,] outputWeights = new double[NumHiddenNodes, NumOutputs]; // hiddenLayer -> output

            // Training data
            double[,] trainingInputs = new double[NumTrainingSets, NumInputs] {
                {0.0f, 0.0f},
                {0.0f, 1.0f},
                {1.0f, 0.0f},
                {1.0f, 1.0f}
            }; 
            double[,] trainingOutputs = new double[NumTrainingSets, NumOutputs] {
                {0.0f},
                {1.0f},
                {1.0f},
                {0.0f}
            };

            // Initialise weights
            for (int i = 0; i < NumInputs; i++)
                for (int j = 0; j < NumHiddenNodes; j++)
                    hiddenWeights[i, j] = InitWeights();

            // Initialise hidden layer bias
            for (int i = 0; i < NumHiddenNodes; i++)
            {
                hiddenLayerBias[i] = InitWeights();
                for (int j = 0; j < NumOutputs; j++)
                    outputWeights[i, j] = InitWeights();
            }

            // Initialise output layer bias
            for (int i = 0; i < NumOutputs; i++)
                outputLayerBias[i] = InitWeights();

            // Training set order
            int[] trainingSetOrder = { 0, 1, 2, 3 }; //Enumerable.Range(0, NumTrainingSets).ToArray();

            // Training loop
            int numEpochs = 50000;
            for (int epoch = 0; epoch < numEpochs; epoch++)
            {
                // Shuffle training set order
                trainingSetOrder = trainingSetOrder.OrderBy(_ => random.Next()).ToArray();

                Console.WriteLine("Epoch: " + (epoch + 1));

                for (int idx = 0; idx < NumTrainingSets; idx++)
                {
                    int i = trainingSetOrder[idx];

                    // --------------- Forward pass ---------------

                    // Compute hidden layer activation
                    for (int j = 0; j < NumHiddenNodes; j++)
                    {
                        double activation = hiddenLayerBias[j];

                        for (int k = 0; k < NumInputs; k++)
                            activation += trainingInputs[i, k] * hiddenWeights[k, j];
                    
                        hiddenLayer[j] = SigmoidFunction(activation);
                    }

                    // Compute output layer activation
                    for (int j = 0; j < NumOutputs; j++)
                    {
                        double activation = outputLayerBias[j];

                        for (int k = 0; k < NumHiddenNodes; k++)
                            activation += hiddenLayer[k] * outputWeights[k, j];
                    
                        outputLayer[j] = SigmoidFunction(activation);
                    }

                    // Print forward pass results
                    Console.WriteLine("Input: " + trainingInputs[i,0] + " " + trainingInputs[i,1] + 
                                      "\tOutput: " + outputLayer[0] + 
                                      "\tPredicted Output: " + trainingOutputs[i,0]);
                                        
                    // --------------- Backward propagation ---------------

                    // Compute change in output layer
                    double[] deltaOutput = new double[NumOutputs];
                    for (int j = 0; j < NumOutputs; j++)
                    {
                        double errorOutput = trainingOutputs[i, j] - outputLayer[j];
                        deltaOutput[j] = errorOutput * DerivateSigmoidFunction(outputLayer[j]);
                    }     

                    // Compute change in hidden layer weights
                    double[] deltaHidden = new double[NumHiddenNodes];
                    for (int j = 0; j < NumHiddenNodes; j++)
                    {
                        double errorHidden = 0.0f;
                        for (int k = 0; k < NumOutputs; k++)
                            errorHidden += deltaOutput[k] * outputWeights[j, k];
                        deltaHidden[j] = errorHidden * DerivateSigmoidFunction(hiddenLayer[j]);
                    }

                    // Apply changes to output layer
                    for (int j = 0; j < NumOutputs; j++)
                    {
                        outputLayerBias[j] += deltaOutput[j] * learningRate;
                        for (int k = 0; k < NumHiddenNodes; k++)
                            outputWeights[k, j] += hiddenLayer[k] * deltaOutput[j] * learningRate;
                    }

                    // Apply changes to hidden layer
                    for (int j = 0; j < NumHiddenNodes; j++)
                    {
                        hiddenLayerBias[j] += deltaHidden[j] * learningRate;
                        for (int k = 0; k < NumInputs; k++)
                            hiddenWeights[k, j] += trainingInputs[i, k] * deltaHidden[j] * learningRate;
                    }
                }

                Console.WriteLine();
            }

            // Output wights & biases

            Console.Write("\nFinal Hidden Weights:\n");
            for (int j = 0; j < NumHiddenNodes; j++)
            {
                Console.Write("\t[   ");
                for (int k = 0; k < NumInputs; k++)
                    Console.Write(hiddenWeights[k, j] + "   ");
                Console.Write("]\n");
            }
                
            Console.Write("Final Hidden Biases:\n\t[   ");
            for (int j = 0; j < NumHiddenNodes; j++)
                Console.Write(hiddenLayerBias[j] + "   ");
            Console.Write("]\n");

            Console.Write("Final Output Weights: ");
            for (int j = 0; j < NumOutputs; j++)
            {
                Console.Write("\n\t[   ");
                for (int k = 0; k < NumHiddenNodes; k++)
                    Console.Write(outputWeights[k, j] + "   ");
                Console.Write("]\n");
            }

            Console.Write("Final Output Biases:\n\t[   ");
            for (int j = 0; j < NumOutputs; j++)
                Console.Write(outputLayerBias[j] + "   ");
            Console.Write("]\n");
        }

        // Initialise weights with random numbers
        static double InitWeights()
        {
            return random.NextDouble();
            //return (double)random.Next() / Int32.MaxValue;
        }

        // Sigmoid function
        // x = sumWeights * inputs + bias
        static double SigmoidFunction(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        // Derivative of the sigmoid function
        static double DerivateSigmoidFunction(double x)
        {
            return x * (1 - x);
        }
    }
}