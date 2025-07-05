public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /* STEP-BY-STEP STRATEGY FOR MULTIPLESOF:
         * 
         * 1. Create a double array with the size specified by 'length'
         * 2. Use a for loop that iterates from 1 to 'length' (inclusive)
         * 3. In each iteration, calculate the corresponding multiple:
         *    - For position i (0-based), the multiple will be: number * (i + 1)
         *    - This gives us: number * 1, number * 2, number * 3, etc.
         * 4. Store each multiple in the corresponding position of the array
         * 5. Return the complete array
         * 
         * Example: MultiplesOf(7, 5)
         * - Create array of size 5
         * - Position 0: 7 * 1 = 7
         * - Position 1: 7 * 2 = 14
         * - Position 2: 7 * 3 = 21
         * - Position 3: 7 * 4 = 28
         * - Position 4: 7 * 5 = 35
         * - Result: {7, 14, 21, 28, 35}
         */

        // Step 1: Create the array with the specified size
        double[] multiples = new double[length];

        // Step 2: Fill the array with the multiples
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple for the current position
            // i + 1 gives us the multiplier (1, 2, 3, 4, 5, etc.)
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the complete array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /* STEP-BY-STEP STRATEGY FOR ROTATELISTRIGHT:
         * 
         * To rotate right, we need to move the last 'amount' elements
         * to the beginning of the list.
         * 
         * Example: {1, 2, 3, 4, 5, 6, 7, 8, 9} with amount = 3
         * - The last 3 elements are: {7, 8, 9}
         * - The first 6 elements are: {1, 2, 3, 4, 5, 6}
         * - Final result: {7, 8, 9, 1, 2, 3, 4, 5, 6}
         * 
         * STEPS:
         * 1. Check for special cases (empty list or amount = 0)
         * 2. Calculate the cut point: where the elements that go to the front start
         *    - This point is: data.Count - amount
         * 3. Extract the last 'amount' elements that will go to the front
         * 4. Extract the first elements that will go to the back
         * 5. Clear the original list
         * 6. Add first the elements that go to the front
         * 7. Add after the elements that go to the back
         * 
         * Detailed example with {1, 2, 3, 4, 5, 6, 7, 8, 9} and amount = 3:
         * - Cut point: 9 - 3 = 6
         * - Elements for the front: elements from index 6 to the end = {7, 8, 9}
         * - Elements for the back: elements from index 0 to 5 = {1, 2, 3, 4, 5, 6}
         * - Result: {7, 8, 9} + {1, 2, 3, 4, 5, 6} = {7, 8, 9, 1, 2, 3, 4, 5, 6}
         */

        // Step 1: Check for special cases
        if (data.Count == 0 || amount == 0 || amount == data.Count)
        {
            // If the list is empty, amount is 0, or amount equals the size,
            // we don't need to do anything (the list remains the same)
            return;
        }

        // Step 2: Calculate the cut point
        int cutPoint = data.Count - amount;

        // Step 3: Extract the last 'amount' elements (that will go to the front)
        // GetRange(startIndex, count) extracts 'count' elements from 'startIndex'
        List<int> elementsToMoveToFront = data.GetRange(cutPoint, amount);

        // Step 4: Extract the first elements (that will go to the back)
        List<int> elementsToMoveToBack = data.GetRange(0, cutPoint);

        // Step 5: Clear the original list
        data.Clear();

        // Step 6: Add first the elements that go to the front
        data.AddRange(elementsToMoveToFront);

        // Step 7: Add after the elements that go to the back
        data.AddRange(elementsToMoveToBack);

        // The list is now rotated right by 'amount' positions
    }
}