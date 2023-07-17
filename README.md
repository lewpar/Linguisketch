# Linguisketch
Linguisketch is a simple language I have written that allows you to create images from text.

## Example
```perl
# Draws a red box with a black outline and some text.
size 256 256

fillcolor red
strokecolor black

fill 0 0 100 100 # Test comment
line 0 0 0 100
line 0 100 100 100
line 100 100 100 0
line 100 0 0 0

fillcolor white
strokecolor black

textsize 16
text 10 200 Hello World!

image 0 0 ./Resources/testemoji.png
```

![ExampleImage](https://cdn.discordapp.com/attachments/814444289181351968/1130296816240443432/fw4bpcxq.u3b.png)
