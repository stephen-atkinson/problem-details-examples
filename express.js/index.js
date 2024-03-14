const express = require('express')
const { HttpProblemResponse } = require('express-http-problem-details')
const { DefaultMappingStrategy, MapperRegistry } = require('http-problem-details-mapper')
const NotFoundError = require('./not-found-error.js')
const NotFoundErrorMapper = require('./not-found-error-mapper.js')

const app = express()

const strategy = new DefaultMappingStrategy(
    new MapperRegistry().registerMapper(new NotFoundErrorMapper()))

app.get('/donuts/:id', async (req, res, next) => {
    next(new NotFoundError({type: 'donut', id: req.params.id, url: req.url }))
})

app.use(HttpProblemResponse({strategy}))
 
app.listen(3000)