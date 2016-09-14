There is a company here in Denmark that makes a "busy light" to give others around your office an idea of whether they should approach you or not. Not only is it a light, but it has built-in speakers! It can can sit on top of your monitor or attach to the wall outside your home office and light up based on a status you set manually or based on a status it gets seamlessly through Skype.

That's great and all, especially because we work in an open office and we each get our own light, but surely we can come up with something a bit more creative. For example, I wanted to set mine up to react when my code check-ins pass or fail. I want a quick alert for myself, and I hope that the public nature of the alerts will encourage me to get more green lights than red.

Fortunately, Plenom, the maker of the light, has an SDK to make controlling the light and sound of the device. Unfortunately, though, it's not so easy to see what each method does. What is the difference between "Alert" and "AlertAndReturn"? Spoiler: The latter does the same as the first, but ignores the color you choose and flashes blue instead. Odd, I know.

I'm already done with my check-in alert system which I hope to write up soon, but tonight I took the time to create the tool I wish I had before I started - a simple console app which would let me see the difference between alert and jingle, hear the different sounds, and see just how loud I can set it before I annoy my colleagues.

You can find the source (and an exe) on [github](https://github.com/hoovercj/BusyLight-Demo-CSharp).