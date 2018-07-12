using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VK_COM.Enums
{
    public enum SearchType
    { 
        People,
        Groups,
        Audio,
        Video,
        Images,
        Unknown
    }

    public enum ScheduleType
    { 
        EveryDay,
        Interval,
        ByEvent,
        Unknown
    }

    public enum SearchStrategyType
    {
        BalancedTrees
    }

    public enum StorageType
    { 
        File,
        DataBase,
        Unknown
    }

    public enum AuthType
    { 
        OAuth,
        Unknown
    }

    public enum Commands
    { 
        GetUser,
        GetFriends,
        AreFriends
    }

    public enum FileType
    { 
        Text,
        Html,
        Word,
        Unknown
    }
}
