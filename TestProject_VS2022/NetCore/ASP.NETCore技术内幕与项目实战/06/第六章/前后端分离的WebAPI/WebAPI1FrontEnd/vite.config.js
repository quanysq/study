import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
	plugins: [vue()],
	server:{                 //此处为新增代码
		host:'0.0.0.0',      //此处为新增代码
	}  
})
