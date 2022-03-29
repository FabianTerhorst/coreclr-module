#pragma once

#include <sstream>
#include "../../cpp-sdk/SDK.h"

class Log
{
    std::stringstream buf;

    typedef Log& (*LogFn)(Log&);
    static Log* _Instance;

    enum Type
    {
        INFO,
        DEBUG,
        WARNING,
        ERR,
        COLORED
    } type = INFO;

    Log() = default;

public:
    Log(const Log&) = delete;
    Log(Log&&)      = delete;
    Log& operator=(const Log&) = delete;

    template<class T>
    Log& Put(const T& val)
    {
        buf << val;
        return *this;
    }
    Log& Put(LogFn val)
    {
        return val(*this);
    }
    Log& SetType(Type _type)
    {
        type = _type;
        return *this;
    }
    template<class T>
    Log& operator<<(const T& val)
    {
        return Put(val);
    }

    static constexpr struct Log_Info
    {
        template<class T>
        Log& operator<<(const T& val) const
        {
            return Instance().SetType(INFO).Put(val);
        }
    } Info{};

    static constexpr struct Log_Debug
    {
        template<class T>
        Log& operator<<(const T& val) const
        {
            return Instance().SetType(DEBUG).Put(val);
        }
    } Debug{};

    static constexpr struct Log_Warning
    {
        template<class T>
        Log& operator<<(const T& val) const
        {
            return Instance().SetType(WARNING).Put(val);
        }
    } Warning{};

    static constexpr struct Log_Error
    {
        template<class T>
        Log& operator<<(const T& val) const
        {
            return Instance().SetType(ERR).Put(val);
        }
    } Error{};

    static constexpr struct Log_Colored
    {
        template<class T>
        Log& operator<<(const T& val) const
        {
            return Instance().SetType(COLORED).Put(val);
        }
    } Colored{};

    static Log& Endl(Log& log)
    {
#ifdef DEBUG_CLIENT
        switch(log.type)
        {
            case COLORED: case INFO: std::cout << log.buf.str() << std::endl; break;
            case DEBUG: std::cout << "[DEBUG] " + log.buf.str() << std::endl; break;
            case WARNING: std::cout << "[WARNING] " + log.buf.str() << std::endl; break;
            case ERR: std::cout << "[ERROR] " + log.buf.str() << std::endl; break;
        }
#else
        switch(log.type)
        {
            case INFO: alt::ICore::Instance().LogInfo("[coreclr-module] " + log.buf.str()); break;
            case DEBUG: alt::ICore::Instance().LogColored("[coreclr-module] ~g~[DEBUG] ~w~" + log.buf.str()); break;
            case WARNING: alt::ICore::Instance().LogWarning("[coreclr-module] " + log.buf.str()); break;
            case ERR: alt::ICore::Instance().LogError("[coreclr-module] " + log.buf.str()); break;
            case COLORED: alt::ICore::Instance().LogColored("[coreclr-module] " + log.buf.str()); break;
        }
#endif

        log.buf.str("");
        return log;
    }

    static Log& Instance()
    {
        static Log _Instance;
        return _Instance;
    }
};