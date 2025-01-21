#pragma once

#ifdef JaC_EXPORTS
#define JaC_API __declspec(dllexport)
#else
#define JaC_API __declspec(dllimport)
#endif

extern "C" JaC_API void PyramidC(uint8_t* ptr, uint8_t* tempPtr, int width, int height, int startY, int endY);
