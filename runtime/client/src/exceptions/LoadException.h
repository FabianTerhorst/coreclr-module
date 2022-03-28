#pragma once
#include <stdexcept>

class LoadException : public std::runtime_error
{
    using std::runtime_error::runtime_error;
};