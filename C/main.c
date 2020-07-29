#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#include "coord.c"

int length = 10;

double GenerateHeight(float frequency, float amplitude, int max, int min) {

    double height;
    double minimum = (rand()%min)+1;

    height = (((rand()%max+1)-minimum)*frequency*amplitude);
    return height;
}

int main() {

    struct coord coordinates[length*length];
    double height[length*length];

    time_t tme;
    srand((unsigned)time(&tme));

    for (int layer = 0; layer < 10; layer++) {
        for (int i = 0; i < length*length; i++) {
            height[i] += (GenerateHeight(1.12904f,.5f,10, 10));
        }
    }

    int heightMapIndex = 0;

    for (int x = 0; x < length; x++) {
        for (int z = 0; z < length; z++) {

            double y = height[heightMapIndex];

            coordinates[heightMapIndex].x = x;
            coordinates[heightMapIndex].y = y;
            coordinates[heightMapIndex].z = z;

            heightMapIndex++;
        }
    }

    // printing coordinantes
    for (int coord = 0; coord < length*length; coord++) {
        printf("X: %f Y: %f Z: %f\n",
                    coordinates[coord].x,
                    coordinates[coord].y,
                    coordinates[coord].z);
    }

    return 0;
}