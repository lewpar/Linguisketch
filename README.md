# Linguisketch
Linguisketch is a simple language I have written that allows you to create images from text.

## Example
```
# Draws a red box with a black outline. 
# Width/Height: 100 pixels
fillcolor red
strokecolor black

fill 0 0 100 100
line 0 0 0 100
line 0 100 100 100
line 100 100 100 0
line 100 0 0 0

fillcolor white
strokecolor black

textsize 16
text 10 200 Hello World!
```
