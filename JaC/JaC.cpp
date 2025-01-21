#include "pch.h"
#include "JaC.h"

void PyramidC(uint8_t* ptr, uint8_t* tempPtr, int width, int height, int startY, int endY) {

    int mask[5][5] = { 
        {1, 2, 3, 2, 1},
        {2, 4, 6, 4, 2},
        {3, 6, 9, 6, 3},
        {2, 4, 6, 4, 2},
        {1, 2, 3, 2, 1}
    };
    int maskSum = 81;
    int bpp = 3;
    int heightPx = height * bpp;

    int padding = 0;
    if ((width * bpp) % 4 != 0) {
        padding = 4 - (width * bpp % 4);
    }

    if (!tempPtr) {
        return;
    }
    if (endY > height - 2) {
        endY = height - 2;
    }

    for (int i = startY; i < endY; i++) {
        for (int j = 2; j < width - 2; j++) {

            int sumR = 0;
            int sumG = 0;
            int sumB = 0;

            for (int x = -2; x <= 2; x++) {
                for (int y = -2; y <= 2; y++) {
                    int pixelIndex = ((i + x) * width + (j + y)) * bpp + padding * (i + x);
                    sumR += ptr[pixelIndex] * mask[x + 2][y + 2];
                    sumG += ptr[pixelIndex + 1] * mask[x + 2][y + 2];
                    sumB += ptr[pixelIndex + 2] * mask[x + 2][y + 2];
                }
            }

            int tmpIndex = (i * width + j) * bpp + padding * i;
            tempPtr[tmpIndex] = (uint8_t)(sumR / maskSum);
            tempPtr[tmpIndex + 1] = (uint8_t)(sumG / maskSum);
            tempPtr[tmpIndex + 2] = (uint8_t)(sumB / maskSum);
        }
    }
}