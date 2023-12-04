﻿export class Index {

    static LoadNextInit(dotNet, mainPanel) {
        if (mainPanel != null) {
            mainPanel.addEventListener("scroll", () => {
                const scrollTop = mainPanel.scrollTop
                const scrollHeigth = mainPanel.scrollHeight
                const clientHeight = mainPanel.clientHeight
                let percent = scrollTop * 100 / (scrollHeigth - clientHeight)

                if (percent > 75) {
                    dotNet.invokeMethodAsync("LoadNext")
                }
            })
        }
    }
}