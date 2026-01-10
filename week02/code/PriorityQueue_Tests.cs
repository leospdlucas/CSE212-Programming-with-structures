using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them all
    // Expected Result: Items should be dequeued in order of highest to lowest priority.
    // Defect(s) Found: 
    // 1. Loop only checked to Count - 1, missing last item.
    // 2. Comparison used >= instead of >, causing lower priority items to be chosen incorrectly.
    // 3. Dequeue did not remove the item from the list after returning it.

    public void TestPriorityQueue_1() {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);
        
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priorities - should follow FIFO for same priority
    // Expected Result: First item added with priority X should be the first dequeued among items with priority X.
    // Defect(s) Found: Idem above
    public void TestPriorityQueue_2() {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Mix of same and different priorities
    // Expected Result: Highest priority first, then FIFO within same priority
    // Defect(s) Found: Idem above
    public void TestPriorityQueue_3() {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 2);
        
        Assert.AreEqual("B", priorityQueue.Dequeue());  // First with priority 5
        Assert.AreEqual("C", priorityQueue.Dequeue());  // Second with priority 5
        Assert.AreEqual("A", priorityQueue.Dequeue());  // First with priority 2
        Assert.AreEqual("D", priorityQueue.Dequeue());  // Second with priority 2
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: Should throw InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None 
    public void TestPriorityQueue_4_EmptyQueue() {
        var priorityQueue = new PriorityQueue();
        
        try {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");

        }catch (InvalidOperationException e) {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: Should dequeue that item successfully
    // Defect(s) Found: Would fail with original code (Count-1 loop wouldn't execute)
    public void TestPriorityQueue_5_SingleItem() {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 1);
        
        Assert.AreEqual("Only", priorityQueue.Dequeue());
    }
}