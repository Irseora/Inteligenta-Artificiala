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
            const double learningWeight = 0.1f;

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

            for (int i = 0; i < NumHiddenNodes; i++)
                for (int j = 0; j < NumOutputs; j++)
                    outputWeights[i, j] = InitWeights();

            // Initialise output layer bias
            for (int i = 0; i < NumOutputs; i++)
                outputLayerBias[i] = InitWeights();

            // Training set order
            int[] trainingSetOrder = Enumerable.Range(0, NumTrainingSets).ToArray();

            // Training loop
            int numEpochs = 10000;
            for (int epoch = 0; epoch < numEpochs; epoch++)
            {
                // Shuffle training set order
                trainingSetOrder = trainingSetOrder.OrderBy(_ => random.Next()).ToArray();

                // Loop through
                for (int idx = 0; idx < NumTrainingSets; idx++)
                {
                    int i = trainingSetOrder[idx];

                    // Forward pass

                    // Compute hidden layer activation
                    for (int j = 0; j < NumHiddenNodes; j++)
                    {
                        double activation = hiddenLayerBias[j];

                        for (int k = 0; k < NumInputs; k++)
                            activation += trainingInputs[i, k] * hiddenWeights[k, j];
                    }
                }
            }
        }

        // Initialise weights with random numbers
        static double InitWeights()
        {
            return random.NextDouble() / (double)Int32.MaxValue;
        }

        // Sigmoid function
        // x = sumWeights * inputs + bias
        double SigmoidFunction(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        // Derivative of the sigmoid function
        double DerivateSigmoidFunction(double x)
        {
            return x * (1 - x);
        }
    }
}