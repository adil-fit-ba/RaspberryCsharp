#include <stdio.h>
#include <string.h>
#include <errno.h>
#include <stdlib.h>
#include <wiringPi.h>


// Use GPIO Pin 17, which is Pin 0 for wiringPi library

#define BUTTON_PIN 5
#define	LED	6
#define	LED2 7

// the event counter 
volatile int eventCounter = 0;
volatile bool okidac = FALSE;

// -------------------------------------------------------------------------
// myInterrupt:  called every time an event occurs
void myInterrupt(void) {

	printf("Interrupt");
	eventCounter++;
	
	for (int i = 0; i < 100; i++)
	{
		digitalWrite(LED2, HIGH);  // On
		delay(5); // ms
		digitalWrite(LED2, LOW);	  // Off
		delay(5);
	}
	printf("Interrupt pred kraj\n");
	okidac = TRUE;
}


// -------------------------------------------------------------------------
// main
int main(void) {

	wiringPiSetup();

	pinMode(LED, OUTPUT);
	pinMode(LED2, OUTPUT);
	
	digitalWrite(LED, HIGH);
	digitalWrite(LED2, HIGH);
	

	// set Pin 17/0 generate an interrupt on high-to-low transitions
	// and attach myInterrupt() to the interrupt
	if (wiringPiISR(BUTTON_PIN, INT_EDGE_RISING, &myInterrupt) < 0) {
		fprintf(stderr, "Unable to setup ISR: %s\n", strerror(errno));
		return 1;
	}

	

	// display counter value every second.
	while (1) {
		for (int i = 0; i < 20; i++)
		{
			digitalWrite(LED2, HIGH);  // On
			delay(5); // ms
			digitalWrite(LED2, LOW);	  // Off
			delay(5);

		}

		printf("Glavni program while petlja START\n");
		for (int i = 0; i < 100; i++)
		{
			digitalWrite(LED, HIGH);  // On
			delay(500); // ms
			digitalWrite(LED, LOW);	  // Off
			delay(500);
			printf(" ---Glavni program for petlja\n");
			okidac = FALSE;
		}
		printf("Glavni program while petlja KRAJ\n");
		delay(1000);
	}

	return 0;
}