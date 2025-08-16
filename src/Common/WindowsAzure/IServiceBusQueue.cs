using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions;

namespace ServiceBusExplorer.WindowsAzure
{
    internal interface IServiceBusQueue : IServiceBusEntity
    {
        QueueInfo CreateQueue(QueueInfo description);

        Task DeleteQueue(QueueInfo queueDescription);

        Task DeleteQueues(IEnumerable<string> queues);

        QueueInfo GetQueue(string path);

        Uri GetQueueDeadLetterQueueUri(string queuePath);

        IEnumerable<QueueInfo> GetQueues(string filter, int timeoutInSeconds);

        Uri GetQueueUri(string queuePath);

        QueueInfo RenameQueue(string path, string newPath);

        QueueInfo UpdateQueue(QueueInfo description);
    }
}
