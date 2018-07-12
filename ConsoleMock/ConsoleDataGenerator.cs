using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkSearch.Events;
using VkSearch.Events.EventsImpl;
using System.Threading;

namespace ConsoleMock
{
    public class ConsoleDataGenerator
    {
        private static int COUNT = 200;
        private static bool isStopped = false;

        public static void generateData(ISearchSubscriber subscriber)
        {
            subscriber.onSearchStarted();
            Random rnd = new Random();
            for (int i = 0; i < COUNT; i++)
            {
                if (isStopped)
                {
                    isStopped = false;
                    subscriber.onSearchFinished();
                    break;
                }

                Thread.Sleep(200);
                subscriber.onItemFoundEvent(new ItemUpdatedEvent("TEST ITEM " + rnd.Next(1, 50000)));
            }
            subscriber.onSearchFinished();
        }

        public static void stopSearch()
        {
            isStopped = true;
        }

    }
}
